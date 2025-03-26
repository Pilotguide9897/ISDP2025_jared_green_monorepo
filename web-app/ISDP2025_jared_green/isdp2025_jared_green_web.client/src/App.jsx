// import { useEffect, useState } from 'react';
import './App.css';
// import CalendarContainer from './Components/Calendar/CalendarContainer'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
// Import Component Pages
import Dashboard from "./Pages/DeliverySchedule/DeliverySchedule";
import Login from "./Pages/Login/Login";
import PlaceOrder from "./Pages/PlaceOrder/PlaceOrder";
import ViewOrder from "./Pages/ViewOrder/ViewOrder";
import Error from "./Pages/Error/Error";
import { AuthProvider } from "./Context/AuthContext/AuthContext";
import AuthGatekeeper from './Components/AuthGatekeeper/AuthGatekeeper';




function App() {

    return (
        <AuthProvider>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/PlaceOrder" element={<PlaceOrder /> } /> 
                <Route path="" element={<ViewOrder />} />
                <Route element={<AuthGatekeeper />}>
                    <Route path="/driverdashboard" element={<Dashboard />} />
                </Route>
                <Route path="*" element={<Error />} />
            </Routes>
        </AuthProvider>
    )
}

export default App;