   M S B A M L   `   `   `  ����F  BWPF_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_Control.NavigationWPF_Control.Navigation  5   	   #    WPF_Control.Views.ChatService   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5MVVM$clr-namespace:WPF_Control.Navigation     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6;     � Title$  ChatService��5	   	   $	��450��6   $
��1100��6*    � 
ResizeMode$ NoResize=�67    � DataContext 5
      ,   &WPF_Control.Navigation.MVVM_Navigation  5   
   .��5      � ���#F5F5F5*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6(   �� *CommandLoad_chatService+5       � RowDefinitions 5   
   �� 5      $	��37* �6   �� 5      $
��397* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�6   
   SelectionMode$
 Single=�5         AutoGenerateColumns .  $��2��5    W   ��6   �� *chats+ �� SelectedItem 61   �� *SelectedChat+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6H      
IsReadOnly . 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 61   �� *id+6R     5#      $ Username��6%   $ *	 6T    .  67   �� *
username+6^     5$      $ Message��6%   $ *	 6R    .   66   �� *	message+6\     5%      $ Dispatch time��6%   $ *	 6]    .  6<   �� *dispatchTime+6g   5'      �� 5)   
   $��1��6   $��
20,96,20,0q�6!   $	��Top=�65   $��0q�6M   
������� �� CornerRadius$ 10��6t   $��1��6�   ._�5*      �� $��1��6   $��20q�6)   $��Center=�65   
�������.+�5+      �� $��Chat Service��6    �� Padding$ 85,0,0,0q�60   $��0 0 0 20q�6C   $
��Bold"�6U   $��18(�6g   �� 5-       �� Orientation$ 
Horizontal=�6   $��0 0 0 10q�66   .+�5.      �� $	��Add��6   $��0 10 0 0q�6,   $	��100��6>   ���	#FF97CC8F � Cursor$
 Hand��6�   ��6a   Z� ��6x   �� *ChatAddServiceNav+6�   �� 5/      $��Change��6   $��0 10 0 0q�6/   $	��100��6A   ���	#FF97CC8F��6d   Z� ��6{   �� *CommandChange_chatService+�� 50      $��Delete��6   $��0 10 0 0q�6.   $	��100��6@   ���	#FF97CC8F��6c   Z� ��6z   �� *CommandDelete_chatService+51      �� 53      $��	Clear all��6   ���	#FFCE3324��6D   Z� ��6[   �� *CommandClearAll_chatService+54      55      �� 57   
   $��Right=�6   $��1��6-   $��0,0,5,0q�6=   ��6N   Z� ��6d   �� *	MainNav+��6�   Z� ��58      �� 59       �� ImageSource$F @pack://application:,,,/WPF_Control;component/Resources/Cross.png��6   5;      5<      5=      