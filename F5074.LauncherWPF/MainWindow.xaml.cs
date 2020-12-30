using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.WindowsUI;
using F5074.LauncherWPF.Common;
using F5074.LauncherWPF.Progress;
using F5074.WPF.Common.Model;
using F5074.WPF.Common.Type;
using System;
using System.Collections.Generic;
using System.Windows;

namespace F5074.LauncherWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow {
        IList<MenuModel> menuList = new List<MenuModel>();
        private DocumentPanel documentPanel;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                menuList.Add(new MenuModel() { PRNT_MDL_ID = "E_UserControl", MDL_ID = "T", MDL_NM = "Basic", MDL_DESC = "", PGM_CD = "G", PGM_NM = "", PGM_IMG_NM = "State_Validation_Valid", SRT_ORD_SEQ = 3, SYS_AREA_CD = "E_UserControl", VIS_FLG = "Y", UPD_FLG = "Y" });
                SetMenu();
                this.GridEdit_menu.ItemsSource = menuList;

                documentPanel = this.dockManager.DockController.AddDocumentPanel(Container, new Uri("/F5074.LauncherWPF;component/View/D_CardView/CardView01.xaml", UriKind.Relative));
                documentPanel.Caption = "StartPage";
                documentPanel.Name = "StartPage";
                documentPanel.AllowClose = false;
                //this._Panel.CaptionImage = new BitmapImage(new Uri(SystemProperties.PROGRAM_NAME + "Images/Menu/W9911.png", UriKind.Relative));
                this.dockManager.Activate(documentPanel);
                documentPanel.AllowContextMenu = false;

                this.GridEdit_menu.MouseDoubleClick += GridEdit_menu_MouseDoubleClick;
            }
            catch (Exception ex)
            {
                SystemProperties.ShowError(ex.Message);
                return;
            }
            finally
            {
                if (DXSplashScreen.IsActive) SystemProperties.ScreenClose();
            }
        }

        private void SetMenu()
        {
            int idx = 0;
            for (int enumIdx = 0; enumIdx < Enum.GetNames(typeof(E_UserControl)).Length; enumIdx++)
            {
                idx += 1;
                menuList.Add(new MenuModel() { PRNT_MDL_ID = "T", MDL_ID = idx.ToString(), MDL_NM = ((E_UserControl)enumIdx).ToString(), MDL_DESC = ((E_UserControl)enumIdx).ToString(), PGM_CD = "A", PGM_NM = ((E_UserControl)enumIdx).ToString(), PGM_IMG_NM = "State_Validation_Valid", SRT_ORD_SEQ = idx, SYS_AREA_CD = "E_UserControl", VIS_FLG = "Y", UPD_FLG = "Y" });
            }

            for (int enumIdx = 0; enumIdx < Enum.GetNames(typeof(D_CardView)).Length; enumIdx++)
            {
                idx += 1;
                menuList.Add(new MenuModel() { PRNT_MDL_ID = "T", MDL_ID = idx.ToString(), MDL_NM = ((D_CardView)enumIdx).ToString(), MDL_DESC = ((D_CardView)enumIdx).ToString(), PGM_CD = "A", PGM_NM = ((D_CardView)enumIdx).ToString(), PGM_IMG_NM = "State_Validation_Valid", SRT_ORD_SEQ = idx, SYS_AREA_CD = "D_CardView", VIS_FLG = "Y", UPD_FLG = "Y" });
            }
        }

        private void GridEdit_menu_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                SystemProperties.ScreenShow();

                TreeListNode node = GridEditView_menu.FocusedNode;
                MenuModel menuModel = (MenuModel)GridEdit_menu.GetFocusedRow();

                if (menuModel.PGM_CD.Equals("A"))
                {
                    dockManager.ClosedPanels.Clear();
                    BaseLayoutItem item = dockManager.GetItem(menuModel.PGM_NM);
                    if (item != null)
                    {
                        dockManager.ActiveMDIItem = item;
                        item.AllowSelection = true;
                        item.IsActive = true;

                        if (DXSplashScreen.IsActive) DXSplashScreen.Close();

                        return;

                    }
                    string sUri = String.Format("{0}View/{1}/{2}.xaml", SystemProperties.PROGRAM_NAME, menuModel.SYS_AREA_CD, menuModel.PGM_NM);
                    documentPanel = dockManager.DockController.AddDocumentPanel(Container, new Uri(sUri, UriKind.Relative));
                    documentPanel.Name = menuModel.PGM_NM;
                    documentPanel.ToolTip = menuModel.MDL_DESC;
                    documentPanel.Caption = menuModel.MDL_NM;
                    documentPanel.AllowContextMenu = false;
                    //documentPanel.CaptionImage = new BitmapImage(new Uri(SystemProperties.PROGRAM_NAME + "Images/Menu/" + dao.PGM_NM + ".png", UriKind.Relative));
                    dockManager.Activate(documentPanel);

                    //
                    documentPanel.Loaded += panel_Loaded;

                }
                else
                {
                    if (node.IsExpanded)
                    {
                        node.CollapseAll();
                    }
                    else
                    {
                        node.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                SystemProperties.ShowError(ex.Message);
                return;
            }
            finally
            {
                if (DXSplashScreen.IsActive) SystemProperties.ScreenClose();
            }
        }

        private void panel_Loaded(object sender, RoutedEventArgs e)
        {
            documentPanel.Loaded -= panel_Loaded;
            //DXSplashScreen.Close();
        }

        private enum E_UserControl {
            LogView,
            CaptureView,
            ExcelView,
            TextRemoveView,
        }

        private enum D_CardView {
            CardView01,
        }
    }
}
