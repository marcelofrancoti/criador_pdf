Flash Messages exist under the namespace $rootnamespace$.Extensions. Add this to your "using" list in 
whichever controllers you'd like to return Flash Messages from.

Usage:

Add the following where you'd like your flash messages displayed (generally, the best place is
in your _Layout.cshtml or similar).

    @Html.Partial("_Flash")
    
You'll also need to include these scripts in your _Layout.cshtml or equivalent:

    <script src="@Url.Content("~/Scripts/jquery.cookie.js")"></script>
    <script src="@Url.Content("~/Scripts/jquery.flashmessage.js")"></script>

If you're using MVC5 for your project, you can add these to your BundleConfig.cs.


Creating messages:

Create your messages in your controller like the below example...

// Usage within MVC Controller
[HttpPost]
public ActionResult Create()
{
  return RedirectToAction("Index").Success("Message shown to user after redirect");
}