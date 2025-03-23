import { useAuth } from '../../Context/AuthContext/AuthContext';
import { Navigate, Outlet} from 'react-router-dom';

const AuthGatekeeper = ({ redirectTo = "/" }) => {

    const { token } = useAuth();
    return (
        token ? <Outlet /> : <Navigate to={ redirectTo } replace />
    );
}

export default AuthGatekeeper;