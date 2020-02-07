# simpleAbpNextMysqlDemo

fix the mysql issue
https://github.com/abpframework/abp/issues/2053

> nuget Volo.Abp.EntityFrameworkCore.MySQL package
>

resolve the update-database problem

# 2020-01-09
a): upgrade with the abp vnext framework  v1.1.2

b): add the bacgroundjob with sending email function , however it work falied.

for demo with the issue https://github.com/abpframework/abp/issues/2546

the usage:

1:  start the MysqlDemo.Web with google chrome browser;

2:  open the url:https://localhost:44379/swagger/index.html

3:  try the api route out with /api/app/registration/confirm to trigger the emailsending job

4: the host console will print the below exception info:


```c#

An exception was thrown while activating MysqlDemo.Web.EmailSendingJob.
Autofac.Core.DependencyResolutionException: An exception was thrown while activating MysqlDemo.Web.EmailSendingJob.
 ---> Autofac.Core.DependencyResolutionException: None of the constructors found with 'Autofac.Core.Activators.Reflection.DefaultConstructorFinder' on type 'MysqlDemo.Web.EmailSendingJob' can be invoked with the available services and parameters:
Cannot resolve parameter 'Volo.Abp.Emailing.IEmailSender emailSender' of constructor 'Void .ctor(Volo.Abp.Emailing.IEmailSender)'.

```
5:finally with the help  of @maliming , add the dependancy to MysqlDemoWebModule, the  IEmailSender inject successfully, now the background job work perfectly.

# 2020-02-02

a): upgrade with the abp vnext framework  v2.0.1

b)：solved the following issue:
https://github.com/abpframework/abp/issues/2735

# 2020-02-07
a) setup the raw sql test environment

b) related issue:
https://github.com/abpframework/abp/issues/2778

c) in the project MysqlDemo.Domain.Tests; run the Should_Count_Greater_Than_0_User in the class of SampleDomainTests will get failed.

d) fixed the wrong test error function code.


 
