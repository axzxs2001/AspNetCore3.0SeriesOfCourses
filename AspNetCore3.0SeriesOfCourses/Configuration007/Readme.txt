﻿一、机密文件只能在开发环境下使用
1、.csproj文件的<PropertyGroup></PropertyGroup>节点中添加
  <UserSecretsId>d7a40274-87df-43ba-999b-d8719940b7a7</UserSecretsId>
2、操作机密文件
   a、设置机密文件  dotnet user-secrets set "dbpassword" "123456" --project ".csproj所在目录"
   b、设置多个机密文件  type .\input.json | dotnet user-secrets set --project ".csproj所在目录"
   c、查看机密文件  dotnet user-secrets list --project ".csproj所在目录"
   d、删除机密文件  dotnet user-secrets remove "dbpassword"  --project ".csproj所在目录"
   e、删除所有机密文件 dotnet user-secrets clear --project ".csproj所在目录"
3、ConfigureServices中读取
   var password = Configuration["dbpassword"];

二、环境（Development,Staging,Production）
	在运行前设置ASPNETCORE_ENVIRONMENT环境变量为Development,Staging,Production
	
	a、在开发环境中，项目“属性”-“调试”里设置ASPNETCORE_ENVIRONMENT为Development
	b、Jenkins发布Docker状况下，会在dockefile设置环境变量为Staging
	c、Linux环境下，在Linux的Service文件中配置：Environment=ASPNETCORE_ENVIRONMENT=Production

三、用Azure存配置敏感信息
  1、下载Azure CLI  https://docs.microsoft.com/zh-cn/cli/azure/install-azure-cli-windows?view=azure-cli-latest
  2、安装并运行az login进行登录
