using System;
using BOARD_PROJECT.DotNetNote.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BOARD_PROJECT.DotNetNote
{
    public partial class BoardWrite : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ctlBoardEditorFormControl.FormType = BoardWriteFormType.Write;
        }
    }
}