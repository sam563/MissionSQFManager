# MissionSQFManager
Tools for managing Arma generated SQF mission files.

## Output Formats
* Formatted SQF
* Biedi
* SQM

## Features
* User inputted formatting of SQF including prefix and suffix lines.
* Presets that predetermine almost all options defined in and expandable from the config.
* Option to automatically sort objects by their classname
* Option to replace object classnames from the config (This is primarily for switching map_eu classnames with their lootable and standard Arma counterparts).
* Option for converting all positions to positions relative to either a user inputted position, or an automatically determined point (the center point of all objects)
* Options to filter out Units, Vehicles and Objects

## How To
To get started, load a file. This must be an Arma generated .SQF mission file.
The central list should now be populated with the extracted data from the mission file. This should be reflected in the top left displaying "`x` objects loaded".

### Options

#### Load from file
Opens a file dialog for selecting an SQF file (must be in Arma generated format or similar to function correctly)

#### Line Formatting
`%0` - Classname  
`%1` - Position  
`%2` - Direction  
`%3` - Init  
`%4` - Has Init (If the object has an init this will be true else false)  
`%5` - Comma  (Applies to all but last)  

Example `[%0,%1,%2]%5` could output `["Land_a_stationhouse",[1976.964, 12159.64, 0.2868479],63.81946],`

#### Prefix Line
This is the first line of the output and is primarily used for the opening brace of an array.

#### Suffix Line
This is the final line of the output and is intended for closing and calling a function on the objects array.

#### Preview Modes
Ouput Preview - A preview of the current output.  
Raw Object Data - The umodified source data extracted from the original SQF mission file.  

#### Save Output
Saves the current output to the selected output format.

#### Copy to Clipboard
Copies the current output to the clipboard.

#### Relative Positions
By default when a file is loaded the relative position field is populated by the combined center of all loaded objects.
The user can define their own relative position by inputting each axis split with a comma.

#### Find Center
When clicked the relative position input field will automatically be determined by the center of all objects.

#### Order By Class Name
If checked the objects will be ordered alphanumerically by their classname.

#### Replace Class Names From Config
If checked objects names will be replaced by replacements defined in `config.xml` and can be edited within the `ReplacementClassnames` node formatted as seen below.
```xml
<Classname original="ClassnameToBeReplaced" replacement="ReplacementClassname"/>
```

#### Normalize Direction
Should the direction value be normalized between 0-360?

#### Decimal Places
Number of decimal places used in floating point values (Position and Direction)

#### Presets
Presets predetermine options and formatting for convenience.
Presets can be defined in the `config.xml` within the Presets node of the config.
To add a new preset, in the config use the syntax in the following example:
```xml
    <fn_spawnObjects>
      <Format>[%0, %1, %2]%5</Format>
      <Prefix>[[</Prefix>
      <Suffix>],false,false,false] call fnc_spawnObjects;</Suffix>
      <Indents>1</Indents>
      <ReplaceClassnames>true</ReplaceClassnames>
      <OrderByClassname>false</OrderByClassname>
      <RelativePositions>false</RelativePositions>
      <DiscardObjects>false</DiscardObjects>
      <DiscardUnits>true</DiscardUnits>
      <DiscardVehicles>true</DiscardVehicles>
    </fn_spawnObjects>

```

* Parent Name - Used as the preset dropdown name.
* Format - `String` - How each line should be formatted (Use formatting keys listed in the line formatting section above)
* Prefix - `String` - The first line of the output.
* Suffix - `String` - The last line of the output.
* Idents - `Integer` - Number of indentations on each line (excluding prefix and suffix)
* ReplaceClassnames - `Boolean` - Should the objects names be replaced by the ReplaceClassnames defined in the config?
* OrderByClassname - `Boolean` - Should the objects be ordered by their classname alphanumerically?
* RelativePositions - `Boolean` - Should the objects positions be set relative to the user determined / auto generated relative position?
* DiscardObjects - `Boolean` - Should objects be discarded from the output?
* DiscardUnits - `Boolean` - Should units be discarded from the output?
* DiscardVehicles - `Boolean` - Should vehicles be discarded from the output?
* NormalizeDirection - `Boolean` - Should the direction value be normalized between 0-360?
* DecimalPlaces - `Integer` - Number of decimal places used in floating point values (Position and Direction)
