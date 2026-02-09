# Johns-Lyng-.NET-Web-API

Backend for a ToDo List App where the user must be able to see their TODO list, add items to it and delete items from it

# CORS Configuration

The backend is configured to accept requests from the frontend running on port: 4200.

If you've changed the frontend port, you must update the CORS configuration:

1. Open `Program.cs`
2. Locate the CORS configuration
3. Update the port in `WithOrigins("http://localhost:4200")` to match frontend's new port
4. Restart the backend server