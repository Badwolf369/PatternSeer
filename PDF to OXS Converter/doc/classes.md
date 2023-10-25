@startuml
class Program {
    Chart : Chart
    Main(String[]:args)
}
class Chart {
    -SourceImages : Rasterized PDF
    -<o> Pattern : ChartPattern
    -<o> Key : ChartKey
    +Chart(source:Rasterized PDF)
}
class ChartPattern {
    -SourceImages : OpenCV Image[][]
    -<o> Size : [Integer, Integer]
    -<o> Contents : KeySymbol[][]
    +Grid(parents: OpenCV Image[][], key:ChartKey)
}
class ChartKey {
    -SourceImage : OpenCV Image
    -<o> Symbols : KeySymbol[]
    +ChartKey(source:OpenCV Image)
    +MatchSymbol(image:OpenCV Image) : KeySymbol
}
class KeySymbol {
    -<o> Image : OpenCV Image
    -<o> ThreadColor : String
    -<o> ThreadCount : Integer = 2
    -<i/o> StitchCount : Integer[0..1]
    -<o> ThreadBrand : String = "DMC"
    +KeySymbol(image:OpenCV Image)
}

Chart "1" -l-* Program : < Creates
ChartKey "1..*" -u-* Chart
ChartPattern "1" -u-* Chart
KeySymbol "1..*" -l-o ChartPattern
KeySymbol "1..*" -r-* ChartKey
@enduml
