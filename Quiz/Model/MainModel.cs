using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using System.Timers;

namespace Quiz.Model
{
    public class MainModel
    {
        public Quiz? currentQuiz { get; set; }

        public MainModel()
        {
            currentQuiz = null;
        }

        public void StartQuiz(int id)
        {
            currentQuiz = LoadQuizFromDatabase(id);
        }

        public Quiz LoadQuizFromDatabase(int quizId)
        {
            SQLitePCL.Batteries.Init();
            string query = @"
    SELECT pytania.id AS pytanie_id, pytania.tresc AS pytanie_tresc, odpowiedzi.id AS odpowiedz_id, odpowiedzi.odpowiedz AS odpowiedz_tresc
    FROM pytania
    LEFT JOIN odpowiedzi ON pytania.id = odpowiedzi.id_pytania
    JOIN quizy ON pytania.id_quizu = quizy.id
    WHERE pytania.id_quizu = @QuizId";

            using (SqliteConnection connection = new SqliteConnection(@"Data Source=C:\Users\Jakub\Downloads\quiz-wpf.db"))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@QuizId", quizId);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        Quiz quiz = new Quiz()
                        {
                            Id = quizId,
                            Questions = new List<Question>(),
                            EndTimer = new Timer()
                        };

                        Dictionary<int, Question> questionMap = new Dictionary<int, Question>();

                        while (reader.Read())
                        {
                            int questionId = reader.GetInt32(reader.GetOrdinal("pytanie_id"));
                            int answerId = reader.GetInt32(reader.GetOrdinal("odpowiedz_id"));
                            string answerContent = reader.GetString(reader.GetOrdinal("odpowiedz_tresc"));

                            if (!questionMap.ContainsKey(questionId))
                            {
                                string questionContent = reader.GetString(reader.GetOrdinal("pytanie_tresc"));
                                byte[] data = Convert.FromBase64String(questionContent);
                                string originalString = System.Text.Encoding.UTF8.GetString(data);
                                questionContent = originalString;

                                Question question = new Question()
                                {
                                    Id = questionId,
                                    Content = questionContent,
                                    Answers = new List<Answer>()
                                };

                                questionMap.Add(questionId, question);
                                quiz.Questions.Add(question);
                            }

                            Answer answer = new Answer()
                            {
                                Id = answerId,
                                Content = answerContent
                            };
                            DecryptAnswer(answer);
                            questionMap[questionId].Answers.Add(answer);
                        }

                        return quiz;
                    }
                }
            }
        }
        public void DecryptAnswer(Answer answer)
        {
            byte[] data = Convert.FromBase64String(answer.Content);
            string originalString = System.Text.Encoding.UTF8.GetString(data);
            answer.Content = originalString;
            int number = int.Parse(answer.Content[0].ToString());
            if(number % 2 == 0) answer.IsCorrect = true;
            answer.Content = answer.Content.Substring(1);
        }
        public List<string> GetQuizListFromDatabase()
        {
            SQLitePCL.Batteries.Init();
            string query = "SELECT id, autor, nazwa FROM quizy";

            using (SqliteConnection connection = new SqliteConnection(@"Data Source=C:\Users\Jakub\Downloads\quiz-wpf.db"))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        List<string> quizList = new List<string>();

                        while (reader.Read())
                        {
                            int quizId = reader.GetInt32(reader.GetOrdinal("id"));
                            string quizName = reader.GetString(reader.GetOrdinal("nazwa"));
                            string authorName = reader.GetString(reader.GetOrdinal("autor"));

                            Quiz quiz = new Quiz()
                            {
                                Id = quizId,
                                Name = quizName,
                                Author = authorName
                            };

                            quizList.Add($"{quiz.Name}, {quiz.Author}");
                        }
                        return quizList;
                    }
                }
            }
        }

    }

}


