@startuml
class Main {
    main()
}
class Display {
    image : OpenCV Image
    init(self, image:OpenCV Image)
    view()
}

class Chart {
    Parent : PDFDocument
    Grid : Grid
    Symbols : Symbol[]
    Threads : Thread[]
}
class Grid {
    ParentImages : OpenCV Image[][]
    GridSize : (Integer, Integer)
    GridContents : Symbol[][]
}
class Symbol {
    image : OpenCV Image
    Thread : Thread
}
class Thread {
    TableRow : OpenCV Image
    ThreadColor : String
    SymbolImage : OpenCV Image
    ThreadCount : Integer[0..1]
    StitchCount : Integer[0..1]
    Brand : String = "DMC"
}

Main -r-> "1" Display : Creates
Main -r-> Display : Updates image
@enduml