   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   OdarTec 3-Axes   OdarTec3Axes.UserControl1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     MCustom@http://schemas.microsoft.com/winfx/2006/xaml/presentation/ribbon  3System&clr-namespace:System;assembly=mscorlib  -     >�Name$  RibbonControl�� J� SnapsToDevicePixels . 
���p�$	��137��$	��500��$	��500��$	��150��$��Disabled=� � 	Resources ��%     � BindingGroup &   System.Windows.Data.BindingGroup  .��.  (Microsoft.Windows.Controls.Ribbon.Ribbon  -     Name$ MyRibbon�� J� RenderTransformOrigin$	 0,0&�   IsDropDownOpen . $ �� IsSynchronizedWithCurrentItem$
 TrueY�$	��130��
���p�
�������$��Stretch=�$��0q�$��Stretch=�$��Disabled=�   CheckedBackground
 �����	   CheckedBorderBrush
	 ���F�
   FocusedBackground

 ����    FocusedBorderBrush
 ��İ�   MouseOverBackground
 �����   MouseOverBorderBrush
 ���F�   PressedBackground
 �����   PressedBorderBrush
 ���F�
�������$	��500��$	��500��$	��150��   ContextualTabGroups @  :Microsoft.Windows.Controls.Ribbon.RibbonContextualTabGroup     QuickAccessToolBar @  :Microsoft.Windows.Controls.Ribbon.RibbonQuickAccessToolBar  $
��Auto��
�������   CustomizeMenuButton >  8Microsoft.Windows.Controls.Ribbon.RibbonFilterMenuButton  8  2Microsoft.Windows.Controls.Ribbon.RibbonMenuButton   ControlSizeDefinition C  =Microsoft.Windows.Controls.Ribbon.RibbonControlSizeDefinition  .@�5  /Microsoft.Windows.Controls.Ribbon.RibbonGallery  .@��� �� .@��� $��23��$��23��
�������
�������
���p��� $��23��$��23��
�������
�������
���p��� $��23��$��23��
�������
�������
���p��� $��23��$��23��
�������
�������
���p�   ApplicationMenu =	  7Microsoft.Windows.Controls.Ribbon.RibbonApplicationMenu	  -   $��Me_Main�� 	  AuxiliaryPaneContent$
 Test��   Label$ Datei��   KeyTip$ Datei��$��Center=�$��Center=�$��Center=�$��Center=�
�������
���p�
���p�   .@�m� -    m�Name$ MeI_NewPart��$��neues Bauteil��
���p�.@��� �� m� -   $ MeI_Save��$��	speichern�� m� Icon$  ��m� $��Speichern unter��m� $��Drucken��.@�1
  +Microsoft.Windows.Controls.Ribbon.RibbonTab
  -    
 Name$ RiTa_Sketch��$��Skizze��$	 0,0&�$��Stretch=�$��Disabled=�
����İ�$��88��$	��400��.@�3  -Microsoft.Windows.Controls.Ribbon.RibbonGroup  -     Name$ RiGrou_Sketch��$�� ��$��80��$��0q�$��Stretch=�$��Stretch=�$��0q�
�������
������ $��88��$��88��.@�9  3Microsoft.Windows.Controls.Ribbon.RibbonSplitButton  -     Name$ RiSpliBu_newSketch��$ Skizze erstellen��!   HeaderQuickAccessToolBarId$ Skizze��   HeaderKeyTip$ neue Skizze��   LargeImageSource$b \D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_new-2D.png��  � UseLayoutRounding  .  $��80��!   CheckedBackground
! �����"   CheckedBorderBrush
" � ���#   FocusedBackground
# �����$   FocusedBorderBrush
$ � ���%   MouseOverBackground
% �����&   MouseOverBorderBrush
& � ���'   PressedBackground
' �����(   PressedBorderBrush
( � ���$��Disabled=�))   "CanAddToQuickAccessToolBarDirectly) .  $��80��$��1q�$	��108��$	 0,0&�$��0q�$��-5,0,-5,-20q�$��Bottom=�$	��108��$��80��$	��108��*   LabelPosition$* DropDown=�   +   WidthD  >Microsoft.Windows.Controls.Ribbon.RibbonControlLengthConverter$+ 80 ,   MinWidth$, 80 .@�m� -	   $ MeI_New2DSketch��$��neue 2D-Skizze��m� -
   $ MeI_New3DSketch��$��neue 3D-Skizze��  -   $ RiGrou_SmartDim��$�� ��$��80��$��	0,0,0,-20q�$��Stretch=�$��Disabled=�$��0q�
�������
������ $	��108��$	��108��$��80��$	��Top=�$��Stretch=�.@�  -   $ RiSpliBu_SmartDim��$ Intelligente Bemaßung����. $} wD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_intelligent dimension_1_48x48_144.png��$��Stretch=�
! �����
" � ���
# �����
$ � ���
% �����
& � ���
' �����
( � ���$��80��$��Stretch=�$��Disabled=�$��0q�  . $��-5,0,-5,-20q�$��80��$	��108��$	��108��$* DropDown=�     -   $ RiGrou_SketchElements��$�� �� . $��0q�$��	0,0,0,-50q�$	��203��
�������
������ $��95��$	��203��$��Disabled=�)-   "CanAddToQuickAccessToolBarDirectly- .  $��Stretch=�$��17(�$	��Top=�.@�  -   $ RiSpliBu_SketchLine��$��35��$��Stretch=�$��0q�$��35��. � ToolTip$. Linie��$��Stretch=�  . $ 0.5,0.5&�$��1,1,0,0q�$��25��$��25��$��35��$��25��$��Disabled=�
% �����
& � ���
( � ���
' �����
! �����
" � ���
# �����
$ � ���/   DropDownHeight$/ 25Q� . ��. 0 �� IsTextSearchEnabled0 . $* DropDown=�1   SmallImageSource1 �� 2 �� 	UriSource$v2 pfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_line_1_20x20x256x0.png?�   3   	ImageSize$3 Small=�$+ 35 $, 35 4   MaxWidth$4 35 5   IsLabelVisible5 . .@�m� -   $ MeI_SketchLine��$��Linie��m� -   $  MeI_SketchConstructionLine��$��Konstruktionslinie��m� $��Mittelpunktlinie��  -   $ RiSpliBu_SketchRightAngle��$  ��$��35��$��1,2,0,0q�$��1��$��35��$
��Left=�$��Center=�$��0q�  . $	 0,0&�$��25��6 J� IsHitTestVisible6 .  . $	��Top=�$��25��$��35��$��25��$��Center=�$��Disabled=�) .  
% �����
& � ���
' �����
( � ���
$ � ���
! �����
" � ���
# �����1 �� $�2 ~file:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rightangle_2-point_1_20x20x256x0.png?�   $4 35 $, 35 $+ 35 $3 Small=�5 .  z�V� .~��� �� �� T� .@�;  5Microsoft.Windows.Controls.Ribbon.RibbonSplitMenuItem  -   7  Name$$7 RiSpliMeI_SketchRightAngleEdge��6  0Microsoft.Windows.Controls.Ribbon.RibbonMenuItem8   CheckedBackground
8 �����9   CheckedBorderBrush
9 ���F�$��Ecken-Rechteck��:   MouseOverBackground
: �����;   MouseOverBorderBrush
; ��İ�<   PressedBorderBrush
< ���F�=   PressedBackground
= �����>   ImageSource$y> sD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rightangle_edge_48x48_144 (2).png��  -   $+7 %RiSpliMeI_SketchRightAngleMiddlePoint��
8 �����
9 ���F�$��Mittelpunkt-Rechteck��
: �����
; ��İ�
< ���F�
= �����$�> zD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rightangle_middlepoint_48x48_144 (4).png��  -   $'7 !riSpliMeI_SketchRightAngle3Points��
8 �����
9 ���F�$��Rechteck, 3 Eckpunkte��
: �����
; ��İ�
< ���F�
= �����$|> vD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rightangle_3-point_48x48_144 (1).png��  -   $27 ,RiSpliMeI_SketchRightAngleMiddlePoint3Points��
8 �����
9 ��İ�$$��Mittelpunkt-Rechteck, 3 Punkte��
: �����
; ��İ�
< ���F�
= �����$�> �D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rightangle_middlepoint_3-points_48x48_144 (3).png��  -   $-7 'RiSpliMeI_SketchRightAngleParallelogram��$��Parallelogramm��
: �����
; ��İ�
< ���F�
= �����$~> xD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rightangle_parallelogram_48x48_144.png��  -   $ RiSpliBu_SketchSlot��$  ��$��35��$��25��$��1,2,157,-54q�$u1 oD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_slot_2-points_1_20x20_120.png��$��2��$
��Left=�$��0q�  . $��Center=�$	��Top=�$��35��$��Center=�$��25��$��35��$��25��$��Disabled=�) .  $��6(�
& � ���
! �����
" � ���
# �����
$ � ���
% �����
' �����
( � ���   $4 35 $, 35 $+ 35 $3 Small=�.@��� ��   -   $ RiSpliBu_SketchCircle��$��35��$ 0.5,0.5&�$��
38,-52,0,0q�$��Center=�$
��Left=�  . $��0q�$	��Top=�$��25��$  ��$��Disabled=�$��35��$��25��$��35��$��25��$��Center=�
& � ���
( � ���
' �����
% �����
$ � ���
# �����
" � ���
! ����� . 1 �� $�2 ~file:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_circle_centerpoint_1_20x20x256x0.png?�   $3 Small=�.@�  -   $'7 !RiSpliMeI_SketchCircleCenterPoint��$��Mittelpunkt-Kreis��$n> hD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_circle_centerpoint.png��
8 �����
9 ���F�
: �����
; ��İ�
= �����
< ���F�  -   $#7 RiSpliMeI_SketchCircle3Points��$��3-Punkt-Kreis��$s> mD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_circle_3-point_32x32_96.png��
: �����
; ��İ�
= �����
< ���F�
8 �����
9 ���F�  -   $ RiSpliBu_SketchArc��$t1 nD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_arc_3-points_1_20x20_120.png��$��35��$��25��
���p�? � IsSharedSizeScope? . $��38,-25,110,0q�$��1��$��1��$
��Left=�$��35��$��0q�$��Center=�$	��Top=�$��Disabled=�$��35��$��25��$��25��) .  
& � ���
( � ���
' �����
% �����
$ � ���
# �����
" � ���
! �����   $3 Small=�$4 35 $, 35 $+ 35 .@��� ��   -   $ RiSpliBu_SketchMultiEdge��$  ��$��35��$��25��$��38,2,112,-40q�$��0q�$��35��$
��Left=�$��2��$��1��$	��Top=�$��Center=�  . $��Disabled=�$��25��$��35��$��25��
& � ���) .  
! �����
" � ���
# �����
$ � ���
% �����
' �����
( � ��� . 1 �� $t2 nD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_multi edge_1_24x24x256x0.png?�   $3 Small=�$4 35 5 .  $, 35 $+ 35   -   $ RiSpliBu_SketchSpline��$  ��$��35��$��25��$��75,-52,65,0q�$n1 hD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_spline_1_20x20_120.png��$��2��$
��Left=�$��35��$��0q�$	��Top=�$��Center=�  . $��25��$��35��$��25��$��Disabled=�) .  $��Center=�$��1q�
& � ���
( � ���
' �����
% �����
$ � ���
# �����
" � ���
! �����   $3 Small=�$4 35 $, 35 $+ 35 .@��� ��   -   $ RiSpliBu_SketchEllipse��$  ��$��35��$��25��$��75,-25,62,-12q�$
��Left=�$��1��$��2��$	��Top=�$��35��$��Center=�$��0q�  . $��Disabled=�$��35��$��25��$��25��
& ��İ�) .  
! �����
" ���F�
# ���� 
$ ��İ�
% �����
' �����
( ���F�1 �� $v2 pfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_elipse_1_20x20_120.png?�   $3 Small=�$4 35 $, 35 $+ 35 .@��� ��   -   $ RiSpliBu_SketchEdgeWork��$  ��$��35��$��25��$��75,2,63,-44q�$��2��$��2��$
��Left=�$��35��$��0q�  . $��Center=�$	��Top=�$��25��$��35��$��25��$��Disabled=�
& ��İ�
( ���F�
' �����
% �����
$ ��İ�
# ���� 
" ���F�
! �����1 �� $x2 rfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/sketch_rounding_1_20x20_120.png?�   $3 Small=�5 .  $4 35 $, 35 $+ 35 4  .Microsoft.Windows.Controls.Ribbon.RibbonButton  -    @  Name$@ RiBu_SketchDatums��A   Label$A  ��$��25��$��25��$��112,-52,10,-5q�$��3��$
��Left=�$��2q�  . $	��Top=�? .  $	 0,0&�$��Center=�$��Disabled=�$��25��$��25��$��25��$��25��B   SmallImageSource$sB mD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_datum plane_1_20x20_120.png��C   MouseOverBorderBrush
C � ���D   FocusedBackground
D �����E   FocusedBorderBrush
E � ���F   MouseOverBackground
F �����G   PressedBackground
G �����H   PressedBorderBrush
H � ���I   ControlSizeDefinitionI   $3 Small=�  -!   $@ RiBu_SketchText��$A  ��$��112,-25,0,0q�$��25��$��25��$
��Left=�$	��Top=�
C ��İ�$��25��$��25��$��25��$��25��$��Center=�$��Disabled=�  . 
H ���F�
G ���@�
F �����
E ��İ�
D ���� I   $3 Small=�$4 25 $, 25 $+ 25 B �� $v2 pfile:///D:/softwaredevelopement/3-Axis/software/PC programs/OdarTec 3-Axes/picture/sketch_text_1_20x20x256x0.png?�  -"   $@ RiBu_SketchPoint��$A  ��
C � ���$��25��$��25��$
��Left=�$	��Top=�$��	112,0,0,0q�$��25��$��25��$��25��$��25��$��Center=�$��Disabled=�  . 
H � ���$mB gD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\sketch_point_1_20x20_120.png��)J   "CanAddToQuickAccessToolBarDirectlyJ .  
D ���� 
E � ���
F �����
G �����I   $3 Small=�$4 25 $, 25 $+ 25   $��Extras��$��90��
�������
������  . $��0q�.@�  -#   $@ RiBu_DXFImport��$��25��$A  ��$��25��$jB dD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\SketchImportDXF_48x48.png��K   LargeImageSource$jK dD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\SketchImportDXF_48x48.png��$	��Top=�$��Center=�$
��Left=�$��25��  . L   KeyTip$L 
DXF-Import��M   ToolTipTitle$M Import��
C � ���
F �����
G �����
H � ���
D �����
E � ���$��25��$��25��$��25��I   $3 Small=�$4 25 $, 25 $+ 25   -$   $@ RiBu_PoinCloudImport��$��25��$A  ��$��25��$qB kD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\SketchImportPointCloud_48x48.png��$	��Top=�$��Center=�$
��Left=�$��25��  . $L Punktwolken-Import��$M Import��
C � ���
F �����
G �����
H � ���
D �����
E � ���$��25��$��25��$��25��I   $3 Small=�$4 25 $, 25 $+ 25   -%   $@ RiBu_STLImport��$A Button��$qK kD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\SketchImportPointCloud_48x48.png��$qB kD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture\SketchImportPointCloud_48x48.png��$	��Top=�$��Center=�$
��Left=�$��25��  . $L 
STL-Import��$M Import��
C � ���
F �����
G �����
H � ���
D �����
E � ���$��25��$��25��$��25��$��25��$��
-25,52,0,0q�I   $3 Small=�$4 25 $, 25 $+ 25 
  -&   $ RiTa_Feature��$��Feature��$��95��$	��Top=�$
��Left=�$��95��
  -'   $ RiTa_Cam��$	��CAM��$ 	0.5,0.809&� . $��0q�$
��Left=�
�������$��88��$��Stretch=�$��Disabled=�.@�  -(   $ 
RiGrou_CAM��
�������
������ $��	0,0,0,-50q�$��Disabled=�$��0q�$��88��$��Stretch=�? . - .  $��1(�$	��Top=�.@�� $	��200��$��88��$
��Left=�$��Disabled=�N � RowDefinitionsN �� $��43 �$��43��$��43���� $��43 �$��43��$��43��O � ColumnDefinitionsO �� $��43 ��� $��43 ��� $��43 ��� $��43 �.+�  -)   $@ RiBu_CamPocket��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��0q�$��42��$��42��$��42��$��42��$��Disabled=�$��Center=�  . $��Center=�$. Taschenfräsen��$	��Top=�$��Center=�J .  K �� $u2 ofile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_pocket_1_48x48x256x0.png?�I   $4 25 $, 25 $+ 25 5 .    -*   $@ RiBu_CamPath��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��Center=�$��0q�$��42��$��42��$��42��$��42��$��Center=�  . J .  $��Disabled=�$��Center=�$. Konturfräsen��$��0q�$	��Top=�$��1��K �� $v2 pfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_contour_1_48x48x256x0.png?�B �� $v2 pfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_contour_1_48x48x256x0.png?�I   $4 25 5 .  $, 25 $+ 25   -+   $@ RiBu_CamBore��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��Center=�$	��Top=�$��0q�$��42��$��42��$��42��$��42��$��Disabled=�$��Center=�  . J .  $��Center=�$. Bohren��$��1��K �� $s2 mfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_bore_1_48x48x256x0.png?�B �� $s2 mfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_bore_1_48x48x256x0.png?�I   $4 25 $, 25 $+ 25 5 .    -,   $@ RiBu_CamPicture��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��0q�$��42��$��42��$��42��$��42��$��Disabled=�$��Center=�  . $��Center=�$
. Bild��$	��Top=�$��Center=�J .  $��1��$��1��K �� $v2 pfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_picture_1_48x48x256x0.png?�I   $4 25 $, 25 $+ 25 5 .    --   $@ RiBu_CamFaceMilling��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��Center=�$��0q�$��42��$��42��$��42��$��42��$��Center=�  . J .  $��Disabled=�$��Center=�$. Abzeilen��$��0q�$	��Top=�$��2��K �� $z2 tfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_facemilling_1_48x48x256x0.png?�B �� $z2 tfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_facemilling_1_48x48x256x0.png?�I   $4 25 5 .  $, 25 $+ 25   -.   $@ RiBu_CamScan��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��Center=�$��0q�$��42��$��42��$��42��$��42��$��Center=�  . J .  $��Disabled=�$��Center=�$. Abzeilen��$��0q�$	��Top=�$��2��$��1��K �� $s2 mfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_Scan_1_48x48x256x0.png?�B �� $s2 mfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_Scan_1_48x48x256x0.png?�I   $4 25 5 .  $, 25 $+ 25   -/   $@ 
RiBu_Cam3D��$��42��$A  ��$��42��
D ���� 
E � ���
F �����
C � ���
G �����
H � ���$��Center=�$��0q�$��42��$��42��$��42��$��42��$��Center=�  . J .  $��Disabled=�$��Center=�$. Abzeilen��$��0q�$	��Top=�$��3��K �� $q2 kfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_3D_1_48x48x256x0.png?�B �� $q2 kfile:///D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/cam_3D_1_48x48x256x0.png?�I   $4 25 5 .  $, 25 $+ 25 
  -0   $ RiTa_Evaluate��$��
Evaluieren��$
��Left=�
�������.@�  -1   $ RiGrou_Measurement��$��Messen��.@�  -2   $@ RiBu_Measurement_Measure��$A Button��
D ���� 
E �����
F �����
C ��İ�
G �����
H ���F�$tB nD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/evaluation_measurement_32x32_96.png��
  -3   $ RiTa_Filter��$��Filter��
����İ�.@�  $��Skizze��
�������
������ $��0q�.@�  -4   $@ RiBu_FilterSketchPoints��
D ���� 
E ��İ�
F �����
C ���F�
H ���F�
G �����$qB kD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/filter_sketch_point_32x32_96.png��  -5   $@ RiBu_FilterSketch��
D ���� 
E ��İ�
F �����
C ���F�
H ���F�
G �����$kB eD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/filter_sketch_32x32_96.png��  -6   $@ RiBu_FilterSketchSegments��
D ���� 
E �����
F �����
C ��İ�
H ���F�
G �����$tB nD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/filter_sketch_segments_32x32_96.png��  -7   $#@ RiBu_FilterSketchMiddlePoints��
D ���� 
E �����
F �����
C ��İ�
H ���F�
G �����$wB qD:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\picture/filter_sketch_middlepoint_32x32_96.png��  
D ���� 
E �����$A Button��
F �����
C ��İ�
H ���F�
G �����  
D ���� 
E �����$A Button��
F �����
C ��İ�
H ���F�
G �����  $��Group��
  -8   $ 	RiTa_View��$��Ansicht��.@�  $��Ansicht��  $��Teildarstellung��
  $	��Tab��