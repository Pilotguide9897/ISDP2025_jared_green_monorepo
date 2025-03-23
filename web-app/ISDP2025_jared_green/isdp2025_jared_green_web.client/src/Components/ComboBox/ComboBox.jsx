import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form';

function ComboBox({ label, items, onChange }) {
    return (
        <FloatingLabel controlId="floatingSelect" label={label}>
            <Form.Select aria-label="Floating label select example" onChange={ onChange }>
                {items.map(( item, index ) => (
                <option key={index} value={item}>{ item }</option>
                ))}
            </Form.Select>
        </FloatingLabel>
    );
}

export default ComboBox;