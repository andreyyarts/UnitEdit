   M S B A M L   `   `   `  ����C  ?UnitEdit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UnitEdit.ViewModelsUnitEdit.ViewModels  5
   	   #    UnitEdit.Views.EditUnitWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8
viewModels!clr-namespace:UnitEdit.ViewModels     5
   	     � Title$Y  SДобавление/редактирование единицы измерения��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStartupLocation$ CenterOwner=�5   	    +� FocusedElement 5   	   ��  �� ElementName$ UnitEdit�� � 	Resources 5      -   'UnitEdit.ViewModels.MainWindowViewModel   Windows1ViewModel  textStyleTextBox �� 
TargetType �� Triggers P� Property	 P� Value
 �� Property �� Value �� RelativeSource �� Path��%�   &	        &	        5   
   6)   �� 5   
   " ��6)    5      P� 5       �@=�HasError	 . . �5      �� 
 �@�ToolTip 5      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5      5      5      .��5      �� $��20q�6   .+�5   
   �� -   5        $��UnitEdit��5   ,   $��23��6   $
��0 10q�6   $	��281��6<   #��[ 6�   ��6H   �� $
 Name� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  � DataContext 6�   �� $ CurrentUnit�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��0,20,0,0q�6K   .+�5      �� -   5        $��Сохранить��5       �� 	IsDefault . ��6)   �� $ UnitEdit��$ DataContext���6m   �� $ SaveUnitCommand�6�   �� 5      $��Отмена��6    �� IsCancel . 6&   5       5!      5"      