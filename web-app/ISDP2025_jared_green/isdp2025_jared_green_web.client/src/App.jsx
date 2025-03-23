// import { useEffect, useState } from 'react';
import './App.css';
// import CalendarContainer from './Components/Calendar/CalendarContainer'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
// Import Component Pages
 import Dashboard from "./Pages/DeliverySchedule/DeliverySchedule";
import Login from "./Pages/Login/Login";
//import PlaceOrder from "./Components/Pages/PlaceOrder/PlaceOrder";
//import ViewOrder from "./Components/Pages/ViewOrder/ViewOrder";
import Error from "./Pages/Error/Error";
import { AuthProvider } from "./Context/AuthContext/AuthContext";
import AuthGatekeeper from './Components/AuthGatekeeper/AuthGatekeeper';




function App() {
    //const [userRole, setUserRole] = useState(null);

    return (
        <AuthProvider>
            <Routes>
                {/*For Testing*/}
                {/*<Route path="/" element={<Login onLogin={setUserRole} />} />*/}
                {/*<Route path="/" element={<Login />} />*/}

                {/*<Route path="/PlaceOrder" element={<PlaceOrder /> } /> */}
                {/*<Route path="" element={<ViewOrder />} />*/}

                <Route element={<AuthGatekeeper />}>
                    <Route path="/driverdashboard" element={<Dashboard />} />
                </Route>


                <Route path="*" element={<Error />} />
            </Routes>
        </AuthProvider>
    )
}

export default App;