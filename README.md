# WASimSearchApp

A Windows Forms application for searching and managing Microsoft Flight Simulator 2020/2024 SimVars using the WASimCommander library.

## Overview

WASimSearchApp is a desktop application that provides a user-friendly interface for searching, filtering, and managing SimVars (Simulation Variables) in Microsoft Flight Simulator. It leverages the powerful WASimCommander library to access the simulator's internal variables and provides advanced search and categorization capabilities.

## Features

- **SimVar Management**: Load and manage thousands of SimVars from Microsoft Flight Simulator
- **Advanced Search**: Search SimVars by name, unit, or description
- **Category Filtering**: Filter SimVars by various categories (Camera, Aircraft, Engine, Fuel, etc.)
- **Unit-based Filtering**: Filter SimVars by their units (Degrees, Percent, Meters, etc.)
- **Numeric Variable Detection**: Automatically identify and categorize numeric SimVars
- **Real-time Connection**: Connect to MSFS 2020/2024 using WASimCommander
- **Export Capabilities**: Export SimVar data in various formats

## Dependencies

### Primary Library
- **[WASimCommander](https://github.com/mpaperno/WASimCommander)**: A WASM module and developer API for remote access to Microsoft Flight Simulator 2020 & 2024 "Gauge API" functions. This library provides the core functionality for connecting to and interacting with the simulator.

### Framework
- **.NET 8.0**: The application is built using .NET 8.0 with Windows Forms for the user interface.

## Installation

1. Ensure you have Microsoft Flight Simulator 2020 or 2024 installed
2. Install the WASimCommander module in your MSFS Community folder
3. Build and run the application

## Usage

1. **Connect to Simulator**: Click the connect button to establish a connection with MSFS
2. **Load SimVars**: The application automatically loads SimVars from the `simvar.txt` file
3. **init search**: Use the init search functionality to find specific SimVars value
4. **search**: Use the search new value in init search results

## Project Structure

```
WASimSearchApp/
├── SimvarManager.cs          # Core SimVar management class
├── MainForm.cs               # Main application form
├── Program.cs                # Application entry point
├── simvar.txt               # SimVar definitions file
└── lib/WASimCommander/      # WASimCommander library files
```

## Key Components

### SimvarManager
The core class that manages all SimVar operations:
- Loading SimVars from file
- Searching and filtering
- Categorization by type and unit
- Numeric variable detection

### MainForm
The main user interface that provides:
- Connection management
- Search interface
- Results display

## License

This project is licensed under the same terms as WASimCommander (GPL v3 or LGPL v3).

## Acknowledgments

- **Maxim Paperno**: Creator of WASimCommander library
- **Microsoft/Asobo**: For Microsoft Flight Simulator 2020/2024
- **WASimCommander Community**: For the excellent documentation and support

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

## Support

For issues related to this application, please use the GitHub Issues feature. For WASimCommander-specific issues, please refer to the [WASimCommander repository](https://github.com/mpaperno/WASimCommander).
