
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