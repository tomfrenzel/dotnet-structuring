namespace dotnet_structuring.library
{
    public class Templates
    {
        public string SelectedTemplate { get; set; }

        public void SelcectTemplate(int i)
        {
            switch (i)
            {
                case 1:
                    SelectedTemplate = "console";
                    break;
                case 2:
                    SelectedTemplate = "classlib";
                    break;
                case 3:
                    SelectedTemplate = "mstest";
                    break;
                case 4:
                    SelectedTemplate = "nunit";
                    break;
                case 5:
                    SelectedTemplate = "nunit-test";
                    break;
                case 6:
                    SelectedTemplate = "xunit";
                    break;
                case 7:
                    SelectedTemplate = "page";
                    break;
                case 8:
                    SelectedTemplate = "viewimports";
                    break;
                case 9:
                    SelectedTemplate = "viewstart";
                    break;
                case 10:
                    SelectedTemplate = "web";
                    break;
                case 11:
                    SelectedTemplate = "mvc";
                    break;
                case 12:
                    SelectedTemplate = "console";
                    break;
                case 13:
                    SelectedTemplate = "webapp";
                    break;
                case 14:
                    SelectedTemplate = "angular";
                    break;
                case 15:
                    SelectedTemplate = "react";
                    break;
                case 16:
                    SelectedTemplate = "reactredux";
                    break;
                case 17:
                    SelectedTemplate = "razorclasslib";
                    break;
                case 18:
                    SelectedTemplate = "webapi";
                    break;
                case 19:
                    SelectedTemplate = "globaljson";
                    break;
                case 20:
                    SelectedTemplate = "nugetconfig";
                    break;
                case 21:
                    SelectedTemplate = "webconfig";
                    break;
                case 22:
                    SelectedTemplate = "sln";
                    break;

            }
        }
    }
}
