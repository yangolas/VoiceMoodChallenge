Hi, Welcome to Voice Mood Challlenge.
At first of all, I enjoy a lot of the challenge!.

Steps for runing server:


step 1: =>Install ChatServer.exe,
step 2 =>Install run time for deskport => ChatServer/windowsdesktop-runtime-6.0.3-win-x64.exe
step 3: => Execute by cmd: ChatServer/bin/Debug/net6.0-windowsChatServer.exe "Number of port".

step 4* => If you need intall: ChatClient.exe, 
step 5* => double click ChatClient\bin\Debug\net6.0-windows

Notes Funcionality Server:

=>When server is runing. It is ready for listening websockects, if you haven´t got any client for testing the chat. You can intall my ChatClient.exe and use it.
=>Important: I consider, that the first message sending from Client to Server must be the user name of the client, It is the way that I program for log in the server.
=> If there are a process blocking the port. When you start the server, server notify that the port is busy. When it is free, server connect in the moment notify
and start to listen.
=>When a Message is received in Server, it will be display in the Server Console, and the server redirect the message to the rest of clients if there are more connected,
of course you see in the terminal the resend message to the all users. 
=>Connected and Disconnect Client is notify in server console.
=> If you want to turn off server press "Enter" key or click in the cross button of the console server. Users will be notify.



Metodology apply SOLID:

In the server program, I focus to using all the concepts of SOLID.  For this proyect, that it is so small... with using only the Principle segregation interfaz is enough.
But, I have wanted to show you the differents ways for developing Service with differents principles. for example: 

Notification Server. It is a perfect candidate, for showing you the principle "O" principle open close, you can extend the funcionality of "NotificationServerService" 
at all that you want using the inheritance interface of "INotification".

"UserService" I decided to show  you the principle of "D" inject dependency, in the constructor I attach de dependency that I am going to need and later if I decided to
rename same class basically only I need to change the name of the object in the ctor, finally my dependency is a Interfaz no a object.

"CreateUserService" in this case was needed to create a parent class that contains a touple list "static List<Users>", 
because it is necesary to get it for some service (name-socket).
My classes that inherit of the parents, use all the funcionality plus his own funcionality.
Respected that Barbara Liskov (L) said, my service can replace all the funcionality of the parent.

SettingsSockectService" use the principle of segregation interface (I) "ISendService" has got all the attributes and clases needed it for listen a port...
If you explore the "ISettingsSockectService" you can see that I extend his own funcionality inheritance "ICreateSocket, IGetListenSocket, IGetPort"
that they are the parent with minimals funcionality that my SettingSocketService use al complete..



I have done something about the Test:

I could do a lot unit test for each service. But I thing for showing the main idea for unit test
is enought, that´s why I only chek one service "Users".
I try to apply integration test, but it is dificult because the app is so simply... and there aren´t 
elements (like a BBDD) that represent with the Moq.