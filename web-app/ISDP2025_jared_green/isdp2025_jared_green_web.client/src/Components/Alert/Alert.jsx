import Alert from 'react-bootstrap/Alert';

function AlertMessage({ variant, message }) {
    // var variants = ['primary', 'secondary', 'success', 'danger', 'warning', 'info', 'light', 'dark']

    return (  
        <Alert variant={variant} dismissible>{ message }</Alert>
    );
}

export default AlertMessage;