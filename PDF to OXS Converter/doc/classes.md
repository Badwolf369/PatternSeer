@startuml
class Main {
    Chart : Chart
    Display : Display
}

class Display {
    -image : OpenCV Image
    +Display(image:OpenCV Image)
    +View(self)
    +Update(self, image:OpenCV Image)
}
Display "1" -u-* Main : < Creates
Display <-u- Main : < Updates

class Chart {
    -Parent : Rasterized PDF
    -<o> Grid : Grid
    -<o> Threads : Thread[]
    +Chart(parent:Rasterized PDF)
}
class Grid {
    -ParentImages : OpenCV Image[][]
    -<o> GridSize : [Integer, Integer]
    -<o> GridContents : Symbol[][]
    +Grid(parents: OpenCV Image[][], threads:Thread[])
}
class Symbol {
    -Image : OpenCV Image
    -<o> Thread : Thread = Undefined
    +Symbol(image:OpenCV Image)
    +MatchThread(threads:Thread[]):Boolean
}
class Thread {
    -TableRow : OpenCV Image
    -<o> ThreadColor : String
    -<o> SymbolImage : OpenCV Image
    -<o> ThreadCount : Integer = 2
    -<i/o> StitchCount : Integer[0..1]
    -<o> Brand : String = "DMC"
    +Thread(tableRow:OpenCV Image)
}

Chart "1" -u-* Main : < Creates
Thread "1..*" -d-* Chart
Thread "1" <-d- Symbol: < References
Symbol "1..*" -l-o Grid
Grid "1" -l-* Chart
@enduml
