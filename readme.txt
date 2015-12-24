This is an Android News Clent  use News Publish Server delvopt with Asp.Net and MysSql DataBase .The faction is very simple ,btn it's better than nono.first you can see see the screen cut picture ,and then think a while for download the code .

本应用是一个简单的基于Android客户端的新闻发布系统。功能简单，界面简陋。你可以先看下运行的截图，来考虑下是否使用。分享这个代码的总比什么都没有强些。

开发工具：Eclipse + Visual Studio 2012 + MySQL DataBase

后台登陆名：admin@admin.com 
密码默认为：admin

默认绑定的IP地址是 localhhost
需要与手机联调 需要使用 IISExpress

修改
IISExpress\config 下的文件：applicationhost.config

改成现在的IP地址 x 。

并在 管理员 的模式下运行：

netsh http add urlacl url=http://x:9728/ user=everyone
netsh http add urlacl url=http://x:6677/ user=everyone
pause