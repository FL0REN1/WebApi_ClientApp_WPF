   M S B A M L   `   `   `  ����F  BWPF_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPF_Control.NavigationWPF_Control.Navigation  5   	       WPF_Control.Main   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5MVVM$clr-namespace:WPF_Control.Navigation     5   	     � Title$
  MAIN��5
   	   $	��450��6   $	��800��6#    � 
ResizeMode$ NoResize=�6/    � DataContext 5      ,   &WPF_Control.Navigation.MVVM_Navigation  5   
    � 	Resources 5         SansSerifCollection  HeaderBackground �� Color  NavigationButtonBackground��%�   &	        &	 C     &	 d     *�5   
   /+Segoe UI, Helvetica Neue, Arial, sans-serif)�6^   �� 5   
   $ #212121��63   �� 5   
   $ 	#FFE4E4E4��6=   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��228 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��2��6    �� CornerRadius$ 	0,0,20,20��6%   #��[ 6>   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��20q�6M   .+�5      �� 
�������$��28(�6/   #��[  6=   $
��Bold"�6o   Welcome to service app!6�   �� 5       $
��10,0q�6   $��Center=�6*   #��["�6E   �� 5!      $��GitHub��6   $
��20,0q�6*   $
��10,0q�68   ���#24292e
�������$��0q�6o   $
��Bold"�6�   $��18(�6�   ��6�   �� *GitHub+5"      5#      �� 5&   
   $��1��6   $��0��6"   ���#F5F5F5$��Center=�6G   $��	20,0,20,0q�6b   $	��320��6u   .+�5'      �� $��
Navigation��6   	 �� Padding$	 30,5,0,5q�6*   $��25(�6=   $��0,0,0,30q�6K   ���	#FFC1C1C1$
��Bold"�6t   �� 5(      $��
Check user��6   $��0,0,0,30q�6*   ���	#FFC1C1C1��6S   Z� ��6j   �� *UserServiceNav+�� 5)      $��
Check chat��6   $��0,0,0,10q�6*   ���	#FFC1C1C1��6S   Z� ��6j   �� *ChatServiceNav+�� 5*      ���#2B2D42$��2q�6+   $	 100��6?   $	��140��6R   $	��140��6^   ���	#FFFDF6F0._�5+      �� $��28(�6X   $
��Bold"�6f   $��Center=�6x   $��Center=�6�   ��6   �� *CurrentTime+
 �� StringFormat$
 {0:HH:mm:ss}��6�   5,      5-      �� 5.   
   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$O Ipack://application:,,,/WPF_Control;component/resources/programmer_gif.gif��6   $��1��5/      $��0,77,0,0q�50      $��UniformToFill=�51      $��2��6    52      53      