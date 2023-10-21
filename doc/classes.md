@startuml
class Main {
    Chart : Chart
    Display : Display
}

class Display {
    image : OpenCV Image
    init(self, image:OpenCV Image)
    view()
}
Display "1" -u-* Main : < Creates

class Chart {
    Parent : PDFDocument
    Grid : Grid
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

Chart "1" -u-* Main : < Creates
Thread "1..*" -d-* Chart
Thread "1" <-d- Symbol: < References
Symbol "1..*" -l-o Grid
Grid "1" -l-* Chart
@enduml