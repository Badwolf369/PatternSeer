@startuml

Actor User
box "View Layer"
Participant MainWindow
end box
box "ViewModel Layer"
Participant MainWindowViewModel
end box
Participant App

Activate App
Activate User

== Setting up View-dependant command ==

App -> MainWindow --++ : Initialize MainWindow
MainWindow -> App --++ : Return MainWindow instance
App -> MainWindowViewModel --++ : Intitialize MainWindowViewModel
MainWindowViewModel -> App --++ : Return MainWindowViewModel instance
App -> App --++ : Bind MainWindowViewModel\nto MainWindow as its\nDataContext
App -> App -- : Bind MainWindow utilities\nto the respective\nMainWindowViewModel\nEventHandlers

== Executing View-dependant command ==

User -> MainWindow ++: Click open\nfile button
MainWindow -->> MainWindowViewModel --++ : Activate OpenFile\n command
MainWindowViewModel -->> MainWindow ++ : Invoke open\nsystem file picker\nevent; Pass event\nan exit callback
MainWindowViewModel -> MainWindowViewModel : Await callback signal
MainWindow -> User --++ : Display file picker to User
User -> MainWindow --++ : User picks file
MainWindow -->> MainWindowViewModel -- : Trigger callback and\npass in picked file
MainWindowViewModel -> MainWindowViewModel --: Do stuff with the file

@enduml