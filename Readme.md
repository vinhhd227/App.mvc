## Controller 
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller 
- Action trong Controller là một phương thức public (ko đc static)
- Action trả về bất kì kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo
## View
- Là file .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
```
// options.ViewLocationFormats.Add("/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
    // {0} -> ten Action
    // {1} -> ten COntroller
    // {2} -> ten Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" +  RazorViewEngine.ViewExtension);
```
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData