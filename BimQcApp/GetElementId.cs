using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace BimQcApp
{
    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class GetElementId : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Get UIDocument
            var uiDoc = commandData.Application.ActiveUIDocument;

            try
            {
                // Pick Object
                Reference pickedObj = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                // Display Element Id
                if (pickedObj != null)
                {
                    TaskDialog.Show("Element Id", pickedObj.ElementId.ToString());
                }

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
