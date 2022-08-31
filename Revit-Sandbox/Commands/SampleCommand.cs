using System;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Revit_Sandbox.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class SampleCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiDocument = commandData.Application.ActiveUIDocument;
            var document = uiDocument.Document;

            var elementId = uiDocument.Selection.PickObject(ObjectType.Element, "Please select an element to start with");
            if (elementId == null) return Result.Cancelled;

            var selectedElement = document.GetElement(elementId);

            TaskDialog.Show("Sample Command", $"Selected element: {selectedElement.Category.Name}", TaskDialogCommonButtons.Ok);

            return Result.Succeeded;
        }
    }
}
