   M S B A M L   `   `   `  ����F  BWPF_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_Control.AddWPF_Control.Add  5   	   6    0WPF_Control.Views.Chat.Components.ChatAddService   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .MVVMclr-namespace:WPF_Control.Add     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  64     � Title$  MESSAGE_ADD��5   	   $	��250��6   $	��400��6*    � DataContext 5	         WPF_Control.Add.MVVM_Add  5
   
   .��5      � *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5   
   +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6(   �� *CommandLoad_chatService+5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��	Username:��6   �� 5   
   $��1��6   $��5q�6!   
���  ����6=   ��  �� Path$) #(Validation.Errors)[0].ErrorContent� �� ElementName$ usernameTextBox���� 5   
   $��0��6   $��5q�6   $	��200��6*   ��66   �� *UsernameChat+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� ValidatesOnDataErrors
 . �� 5   
   $��1��6   $��Message:��6   �� 5   
   $��2��6   $��5q�6!   
���  ����6=   �� $) #(Validation.Errors)[0].ErrorContent�$ messageTextBox���� 5   
   $��1��6   $��5q�6   $	��200��6*   $	��100��66    �� TextWrapping$
 Wrap=�6C    �� AcceptsReturn . ��6l   �� *	Message+$	 PropertyChanged=�
 . �� 5   
   $��3��6   $��5q�6   $	��100��6)   $��30��65   $
��Send��6A   ��6P   �� *CommandSubmit_chatService+5      5       