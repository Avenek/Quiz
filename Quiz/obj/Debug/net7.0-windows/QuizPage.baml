   M S B A M L   `   `   `  ����?  ;Quiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizQuiz  5      /clr-namespace:Quiz.ViewModelQuiz.ViewModel  5          Quiz.QuizPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Quiz     5      +vmclr-namespace:Quiz.ViewModel     5        N� Title$
  Quiz��5	      $	��400��6   $	��800��6!    � DataContext 5
      "   Quiz.ViewModel.QuizViewModel  5   
   -   5        quizViewModel��5      .��5      � -   5         �Name$ QuizPageContainer��5       � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��1* �6   �� 5      $��1* �6   �� 5      .+�5   
   �� $��Pytanie��6   $
��Left=�6"   $��Center=�6=   $��20,0,0,0q�6X   $��24(�6j   $
��Bold"�6x   $��2��6�   $��42��6�   $	��117��6�   �� 5   
   $��24(�6I   $��Center=�6W   $��1��6t   $	��Top=�6�   $��2��6�   ��6   �� *QuestionContent.Content+ �� Mode$ OneWay=�6�   �� 5   
   $��2��6   .+�5      �� $	��360��6   $��44��6#   $��	30,10,0,0q�6I   $	��Top=�6\   ��6/   �� *Check+ d� 	IsChecked 6t   �� *FirstAnswer.IsChoosen+$ TwoWay=�.��5      �� $
��Wrap=�6{   ��6   �� *FirstAnswer.Content+$ OneWay=���6N   �� *FirstAnswerBackground+6{   5      �� 5      $	��360��6   $��44��6#   $��	30,10,0,0q�6I   $��Bottom=�6\   ��6/   �� *Check+ 6w   �� *ThirdAnswer.IsChoosen+$ TwoWay=�.��5       �� $
��Wrap=�6{   ��6   �� *ThirdAnswer.Content+$ OneWay=���6N   �� *ThirdAnswerBackground+6{   5!      5"      �� 5#   
   $��1��6   $��2��6%   .+�5$      �� $	��360��6   $��44��6=   $��	30,10,0,0q�6I   $	��Top=�6\   ��6#   �� *Check+ 6t   �� *SecondAnswer.IsChoosen+$ TwoWay=�.��5%      �� $
��Wrap=�6}   ��6   �� *SecondAnswer.Content+$ OneWay=���6O   �� *SecondAnswerBackground+6}   5&      �� 5'      $	��360��6   $��44��6=   $��	30,10,0,0q�6I   $��Bottom=�6\   ��6#   �� *Check+ 6w   �� *FourthAnswer.IsChoosen+$ TwoWay=�.��5(      �� $
��Wrap=�6}   ��6   �� *FourthAnswer.Content+$ OneWay=���6O   �� *FourthAnswerBackground+6}   5)      5*      �� 5+   
   $��Poprzednie pytanie��6   $��Center=�6S   $��3��6p   $��Center=�6}   $��54��6�   $	��180��6�   ��6.   �� *PreviousQuestion+6�   �� 5,   
   $��Następne pytanie��6   $��Center=�6M   $��3��6j   $��1��6w   $��Center=�6�   $��54��6�   $	��180��6�   ��6,   �� *NextQuestion+6�   �� 5-   
   $��Center=�6�   $��3��6�   $��1��6�   $��Center=�6�   $��54��6�   $	��180��6�   ��6   �� *EndQuizText+$ OneWay=�y�6>   �� *EndQuizVisibility+��6g   �� *	EndQuiz+6�    � 5.   
   -   5        $��	QuizFrame��5.      $��4��6!   $��2��62   �� 5/   
   $
��Left=�6@   $��	110,0,0,0q�6[   $��Center=�6n   $��24(�6�   $
��Bold"�6�   $��2��6�   $��42��6�   $��50��6�   ��6   �� *QuestionNumber+$ OneWay=�6�   �� 50   
   $��1��6   $
��Left=�6L   $��
250,29,0,0q�6g   $	��Top=�6{   ��6    �� *
TimerValue+$ OneWay=�6{   �� 51   
   $
��Left=�6>   $��	50,70,0,0q�6Y   $	��Top=�6l   ��6   �� *PointsNumber+$ OneWay=�6l   52      53      