   M S B A M L   `   `   `  ����  Asennus"    Installer.Views.ProgressView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5
      ]� ��.    LightGrayBrush#��[  5      .+�5   
   ]� ��.  $��Bottom=�5      #��[  5      $��50��5      .+�5      �� $	��Top=�6     DarkGrayBrush#��[ 5      $��0q�5      �� 5        CancelButton#��[ 6   $y�Hidden=�5      �� 5      -   5          ��Name$  
nextButton��5        
NextButton#��[ 5      $
��Next��5      {�.  5      5      ]� 5   
   
�������$��50��5       $	��Top=�5!      .+�5"      �� $��Bottom=�6   #��[ 5#      $��0q�5$      �� 5&      $
��Left=�6     SmallGradientBrush#��[ 5'      $	��200��5(      �� 5*      $��Right=�6     
NormalText#��[ 5+      $��10 5 0 0q�5,      �� 5-      .�6   
Installing6#   �� 5.      /-Please wait while Generic is being installed.50      51      �� 55   
   -   5         ��Name$ currentOperation��55      $	��Top=�56      $��
20 20 20 0q�57       �� MinLines$ 2��58       �� MaxLines$ 2��59       �� 
IsReadOnly . $��0q�5;      #��[  5<       �� TextWrapping$
 Wrap=�5=      $��12(�5>      ��5?      ��  �� Path$ CurrentOperation� �� Mode$ OneWay=�� 5B   
   -   5         �Name$ progress��5B      $	��Top=�5C      $��Stretch=�5D      $
��20 5q�5E      $��30��5F      	 � Value	 5G      �� $ InstallCompletion�$ OneWay=�5H      �� 5K   
   $	��Top=�6   $��20q�5L      $��1q�5M      #��[ 5N      
�������._�5P      �� -   5        
 ��Name$
 detailsScroll��5P      $��Visible=�5Q      .��5R      �� -   5         ��Name$ details��5R      #��[ 5S      $
��Wrap=�5T      $	��5 1q�5U      ��5V      �� $ OperationHistory�$ OneWay=�5W      5X      5Y      5Z      5[      