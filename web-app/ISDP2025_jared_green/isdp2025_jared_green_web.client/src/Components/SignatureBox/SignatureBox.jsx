import SignatureCanvas from 'react-signature-canvas';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

function SignatureBox({ signee }) {
    return (
        <Form>
            <Form.Label htmlFor="basic-url">{`${signee} Signature: `}</Form.Label>
            <SignatureCanvas penColor='green' canvasProps={{ width: 500, height: 200, className: 'sigCanvas' }} />,
            <Button variant="info">Mark Delivered</Button>
            <Button variant="secondary">Exit</Button>
        </Form>
    )
}

export default SignatureBox;