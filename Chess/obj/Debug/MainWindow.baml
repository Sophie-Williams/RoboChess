   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ChessChess  5   	       Chess.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Chess     5   	   -   5          � Title$  	RoboChess��5   	   $	��900��6   $
��1600��6(    � 
ResizeMode$ NoResize=�65   .��5	      � -   5        $��MainGrid��5	      .+�5
   
   �� $��Center=�6    � Cursor$
 None��6-   $$��Resources/ChessBoardPoints.png��6;   ]� 5   
   .+�5      �� $
��Left=�6   $	��360��60   .+�5      �� -   5        $��_txtMoveCount��5      63   �� 5      -   5        $��lbMoves��5      $	��360��6)   $	��864��65   $
��Left=�6B   $��10(�6]   5      �� 5      -   5        $��
_DockRight��5      $��Right=�6+   $	��360��6B   $��0,20,0,0q�6N   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� -   5        $��_btnNewGame��5      $	��100��60   .��6O   
New Game6Z   �� 5      -   5        $��
_btnNGames��5      $	��100��6/   $��10,0,0,0q�6T   .��6f   Play N Games6t   �� 5      -   5        $��
_txtNGames��5      $��30��60    �� TextAlignment$ Center=�6;   .��6R   506V   5      �� 5      $ 
Horizontal=�6   $��Center=�66   .+�5      �� -	   5        $��
_playerOne��5   3   $��
Player One��6   $	��150��6E   $��5q�6Q   .��5      �� -
   5        $��_playerOneBots��5   %   .+�5      	�  d� 	IsChecked$
 TrueY�6*   .��6;   Human6B   5      5      �� 5      -   5        $��
_playerTwo��5   3   $��
Player Two��6   $	��150��6E   $��5q�6Q   .��5      �� -   5        $��_playerTwoBots��5   %   .+�5      	� $
 TrueY�6*   .��6;   Human6B   5      5       5!      �� 5"      $��Bot Options��6   $��Center=�60   $	��300��6M   $��5q�6Y   .��5#      �� .+�5$      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5%      �� -   5        $��_chkWatchBotGame��5%   '   $
 TrueY�6�   $��0,0,20,0q�6�   $��Center=�6�   .��6�   Watch Moves6�   �� 5&      -   5        $��_chkAnimateMoves��5&   '   $
 TrueY�6�   $��0,0,20,0q�6�   $��Center=�6�   .��6�   	Animation6�   5'      �� 5(      $ 
Horizontal=�6%   $��Center=�6>   .+�5)      �� $��Center=�6$   .��6?   Speed6F   �� 5*      -   5        $��
_gameSpeed��5*   %   $	��200��67    � Minimum$ 0Q�6C    � Maximum$	 300Q�6O    � Value$	 200Q�6�   $��10,10,10,10q�6�   $��Center=�6�   5+      �� 5,      -   5        $��_chkWatchBotEndGame��5,   #   $
 TrueY�6�   $��0,0,20,0q�6�   $��Right=�6�   .��6�   View End Result6�   5-      5.      �� 5/      -   5        $��	_lbHeader��5/      $	��150��6-   $��May the best Man/Bot Win!��6:   $��Center=�6[   $��Center=�6v   $��36(�6�   $��WrapWithOverflow=�6�   	 �� Padding$	 10q�6�   6�   �� 50      -   5        $��_GameOnDisplay��50      $y�Hidden=�63   $	��250��6G   .+�51      �� $ 
Horizontal=�6!   $��Center=�6:   .+�52      �� $��Center=�6%   $��0,0,0,20q�6B   .+�53      �� $��Center=�6$   .��6A   
Player One6M   �� 54      -   5        $��_playerOneTeam��54   $   $��Center=�6:   6Y   �� 55      -   5        $��_playerOneBrain��55   (   $��Center=�6?   6^   56      �� 57      $��Center=�6%   .+�58      �� $��Center=�6$   $��
Player Two��6A   �� 59      -   5        $��_playerTwoTeam��59   $   $��Center=�6:   6Y   �� 5:      -   5        $��_playerTwoBrain��5:   (   $��Center=�6?   6^   5;      5<      �� 5=      -   5        $��_HumanGameCommands��5=   !   $ 
Horizontal=�6;   $��Center=�6T   .+�5>      �� -   5        $��_btnUndo��5>   !   $��20��61   $��75��6=   $��0,0,20,0q�6a   .��6s   	Undo-Move6~   �� 5?      -   5        $��_btnRedo��5?   !   $��20��61   $��75��6=   $��0,0,20,0q�6a   .��6s   	Redo-Move6~   5@      5A      &   System.Windows.Controls.DataGrid  5B      -   5        $	��DG1��5B      
   AutoGenerateColumns
 .  $	��200��6Z   ��6&   ��    Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Bot Brain��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *
BotBrain+  5E      $ CM��6-    69   �� *
CheckMates+  5F      $ SM��6-    69   �� *
StaleMates+  5G      $ D��6-    68   �� *Draws+  5H      $ L��6-    68   �� *Losses+  5I      $ 	Avg Moves��6-    6@   �� *
MovesAvg+5K      �� 5L      .��6   42CM = CheckMate, SM = StaleMate, D = Draw, L = Loss6L   �� 5M      -   5        $��	_lbErrors��5M      $	��360��6+   $��10(�67   $��25��6E   $��Visible=�6T   $��75��6�   5N      �� 5O      $	��Top=�6   $��73��6)   67   A� 5P      $��Bottom=�6   $	��200��62   $��73��6>   5Q      A� 5R      -   5        $��MyMainPanel��5R   6   $��Center=�6I   $��Center=�6f   5T      5V      5W      5X      