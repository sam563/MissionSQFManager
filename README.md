# MissionSQFManager
Tools for managing Arma generated SQF mission files.

## Output Formats
* Formatted SQF
* Biedi
* SQM

## Features
* User inputted formatting of SQF including prefix and suffix lines.
* Presets that pre determine almost all options defined and expandable from the config.
* Option to automatically sort objects by their classname
* Option to replace object classnames from the config (This is primarily for switching map_eu classnames with their lootable and standard Arma counterparts).
* Option for converting all positions to positions relative to either a user inputted position, or an automatically determined point (the center point of all objects)
* Options to filter out both Units and Vehicles

## How To
To get started, load a file. This must be an Arma generated .SQF mission file.
The central list should now be populated with the extracted data from the mission file. This should be reflected in the top left displaying "`x` objects loaded".

### Options
#### Line Formatting
`%0` - Classname  
`%1` - Position  
`%2` - Direction  
`%3` - Init  
`%4` - Has Init  
`%5` - Comma  

Example `[%0,%1,%2]%5` could output `["Land_a_stationhouse",[1976.964, 12159.64, 0.2868479],63.81946],`

#### Preview Modes
Ouput Preview - A preview of the current output.  
Raw Object Data - The umodified source data extracted from the original SQF mission file.  

#### Load from file
Opens a file dialog for selecting an SQF file (must be in Arma generated format or similar to function correctly)

#### Save Output
Saves the current output to the selected output format.

#### Relative Positions
By default when a file is loaded the relative position field is populated by the combined center of all loaded objects.
The user can define their own relative position by inputting each axis split with a comma.

#### Presets
Presets pre determine options and formatting for convenience.
Presets can be defined in the config.xml within the Presets node of the config.
to add a new preset use the syntax in the following example:
```xml
    <fn_spawnObjects>
      <Format>[%0, %1, %2]%5</Format>
      <Prefix>[[</Prefix>
      <Suffix>],false,false,false] call fnc_spawnObjects;</Suffix>
      <Indents>1</Indents>
      <ReplaceClassnames>true</ReplaceClassnames>
      <OrderByClassname>false</OrderByClassname>
      <RelativePositions>false</RelativePositions>
      <DiscardUnits>true</DiscardUnits>
      <DiscardVehicles>false</DiscardVehicles>
    </fn_spawnObjects>

```

* Parent Name - Used as the preset dropdown name.
* Format - `String` - How each line should be formatted (Use formatting keys listed above)
* Prefix - `String` - The first line of the output.
* Suffix - `String` - The last line of the output.
* Idents - `Integer` - Number of intentations on each line (excluding prefix and suffix)
* ReplaceClassnames - `Boolean` - Should the objects names be replaced by the ReplaceClassnames defined in the config?
* OrderByClassname - `Boolean` - Should the objects be ordered by their classname alphanumerically?
* RelativePositions - `Boolean` - Should the objects positions be set relative to the user determined / auto generated relative position?
* DiscardUnits - `Boolean` - Should units be discarded from the output?
* DiscardVehicles - `Boolean` - Should vehicles be discarded from the output?

