using Hydra;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

[assembly: CallbackAssemblyDescription(Name: "ONE-001",
                                           Description: "Excel -> Faktura Sprzedaży",
                                           Author: "OneSupport",
                                           Version: "1.0",
                                           SystemVersion: "2020.2.2",
                                           Created: "24-05-2021")]
namespace ZZnaCVS
{
    [SubscribeProcedure(Procedures.ListaDokumentow, "Excel->Faktura Sprzedaży")]
    public class DodajFakture : Callback
    {
        private ClaWindow RapButton;
        private ClaWindow zakladkaTabWewnetrzne;
        private ClaWindow filtrBtn;
        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenWindow));
            //AddSubscription(false, 0, Events.ResizeWindow, new TakeEventDelegate(Resize));
        }



        private bool OnOpenWindow(Procedures ProcId, int ControlId, Events Event)
        {

            ClaWindow Parent = GetWindow();
            Rectangle WndBnd = GetWindow().Bounds;
            zakladkaTabWewnetrzne = GetWindow().AllChildren["?TabFS"];
            RapButton = zakladkaTabWewnetrzne.Children.Add(ControlTypes.button);
            RapButton.Visible = true;
            RapButton.TextRaw = "XLXS";
            RapButton.ToolTipRaw = "Dodaj Fakturę";
            RapButton.OnAfterMouseDown += new TakeEventDelegate(BtnOnMouseDown);

            filtrBtn = GetWindow().AllChildren["?ZwiazaneHan:Button"];                            //pobiera współrzędne przycisku zapisz
            RapButton.Bounds = new Rectangle(filtrBtn.Bounds.X + 18, filtrBtn.Bounds.Y, 17, 15);
            //listID = GetWindow().AllChildren["?Handlowe"].Id;      //tu sprawdzic

            //pobrane z pola w zakładce Raporty
            return true;
        }
        private bool BtnOnMouseDown(Procedures ProcId, int ControlId, Events Event)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Process.Start("C:\\Users\\magdaw\\Documents\\XL_Excel\\one034 form\\build one34\\ONE034.exe");

            return true;
        }
        #region
        public override void Cleanup()
        {
        }
    }
}

#endregion