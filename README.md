# davvisámegillii
Code related to my Northern Sami studies.

## Numerals
Converts an `int` to text (i.e. numerals or ordinal numbers). 

- 42 -> njealljelogiguokte
- 579 -> vihttačuođičiežalogiovcci
- 1723 -> duhátčiežačuođiguoktelogigolbma
- `int.MaxValue` (2147483647) -> guoktemiljárddačuođinjealljelogičiežamiljovnnanjeallječuođigávccilogigolbmaduhátguhttačuođinjealljelogičieža
- 1<sup>st</sup> -> vuosttaš
- 24<sup>th</sup> -> guokteloginjealját

## Dates
Converts a `DateTime` to text:

- 2022-11-28 -> mánnodat skábmamánu guoktelogigávccát beaivi

## Times

Converts a `TimeSpan` to text:

- 03:30: diibmu lea beal njeallje
- 03:45: diibmu lea goartil váile njeallje
- 03:50: diibmu lea logi váile njeallje
- 04:00: diibmu lea njeallje
- 04:05: diibmu lea vihtta badjel njeallje
- 04:25: diibmu lea vihtta váile beal vihtta

### TODO

 - Support for ordinals is limited to <1000. 
 - Not too sure about the implementation of *miljovnna* and *miljárdda*.
