   M S B A M L   `   `   `  ���� M  IAppInsightsTestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AppInsightsTestAppAppInsightsTestApp  #    AppInsightsTestApp.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:AppInsightsTestApp     -     � Title$  AppInsighsTestApp��$	��470��$	��500��.��� 
������� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��23 ��� $
��Auto � � ColumnDefinitions �� �� �� .+��� $��0��$��0��$��3�� �� Orientation$ Vertical=�.+��� -    ��Name$ ComboValueTextBlock��$��Center=�$
��20,0q�$��31(�$
��Wrap=�$��0��$	��Top=��� -   $ ComboTextBlock��$��Center=�$��
20,0,20,20q�$
��Wrap=�$��COMBO��$	��Top=�$
��Bold"��� -    ��Name$ ExceptionButton��$��0��$��0��$��31��$
��Left=�$	��Top=�$��7q�
�������.���� $ 
Horizontal=�.+��� $��5q�$��23��$��Images/Exce.png���� $��0q�
������� �� TextAlignment$ Center=�$��Center=�$��	Exception���� -   $��ExceptionTextBlock��$��5q�
�������$ Center=�$��Center=�$�� ���� -   $ CrashButton��$��0��$��2��$��31��$��Right=�$	��Top=�$��7q�
�������.���� $ 
Horizontal=�.+��� $��5q�$��23��$��Images/Exce.png���� $��5q�
�������$ Center=�$��Center=�$��Crash��� -   $��ComResultPanel��$��1��$��0��$��3��$	��100��.+��� $ Vertical=�$
��Auto��$��Center=�.+��� -   $��ComResultImage��$��5q�$��31���� -	   $��ComResultTextBlock��
�������$ Center=��� $��1��$��0��$
��Left=�$��10q�$
��Wrap=�$��COMPUTER��$��15(�
�������$	��Top=��� -
   $ ResultTextBlock��$��2��$��0��$��3��$��20q�$��Center=�$
��Wrap=�$��23(�$�� ��$	��Top=�$
��Bold"�� -   $��PlayerResultPanel��$��3��$��0��$��3��$	��100��.+��� $ Vertical=�$
��Auto��$��Center=�.+��� -   $��PlayerResultImage��$��5q�$��31���� -   $��PlayerResultTextBlock��
�������$ Center=��� -   $ UserNameTextBlock��$��3��$��0��$
��Left=�$��10q�$
��Wrap=�$��PLAYER��$��15(�
�������$��Bottom=��� -   $ ScissorButton��$��5��$��0��$��Stretch=�$��3q�
�������.���� $ 
Horizontal=�.+��� $��5q�$��23��$��Images/Scissor.png���� 
�������$ Center=�$��Center=�$��Scissor���� -   $ StoneButton��$��5��$��1��$��Stretch=�$��3q�
�������.���� $ 
Horizontal=�.+��� $��5q�$��23��$��Images/Stone.png���� 
�������$ Center=�$��Center=�$��Stone���� -   $ Paperbutton��$��5��$��2��$��Stretch=�$��3q�
�������.���� $ 
Horizontal=�.+��� $��5q�$��23��$��Images/Paper.png���� 
�������$ Center=�$��Center=�$��Paper��