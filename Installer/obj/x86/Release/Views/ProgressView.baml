   M S B A M L   `   `   `  ����   Asennus"    Installer.Views.ProgressView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��]� ��.    LightGrayBrush#��[  .+�]� ��.  $��Bottom=�#��[  $��50��.+��� $	��Top=�  DarkGrayBrush#��[ $��0q���   CancelButton#��[ $y�Hidden=��� -     ��Name$  
nextButton��  
NextButton#��[ $
��Next��{�.  ]� 
�������$��50��$	��Top=�.+��� $��Bottom=�#��[ $��0q��� $
��Left=�  SmallGradientBrush#��[ $	��200���� $��Right=�  
NormalText#��[ $��10 5 0 0q��� .�
Installing�� /-Please wait while Generic is being installed.�� -    ��Name$ currentOperation��$	��Top=�$��
20 20 20 0q� �� MinLines$ 2�� �� MaxLines$ 2�� �� 
IsReadOnly . $��0q�#��[   �� TextWrapping$
 Wrap=�$��12(�����  �� Path$ CurrentOperation� �� Mode$ OneWay=�� -    �Name$ progress��$	��Top=�$��Stretch=�$
��20 5q�$��30��	 � Value	 �� $ InstallCompletion�$ OneWay=��� $	��Top=�$��20q�$��1q�#��[ 
�������._��� -   
 ��Name$
 detailsScroll��$��Visible=�.���� -    ��Name$ details��#��[ $
��Wrap=�$	��5 1q����� $ OperationHistory�$ OneWay=�