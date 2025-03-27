import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Form from 'react-bootstrap/Form';

function ComboBox({ label, items, onChange }) {
    //console.log(label);
    //console.log(JSON.stringify(items));
    return (
        <FloatingLabel controlId="floatingSelect" label={label}>
            <Form.Select aria-label="Floating label select example" onChange={(evt) => onChange(evt) }>
                {items.map(( item, index ) => (
                <option key={index} value={item.siteId}>{ item.siteName }</option>
                ))}
            </Form.Select>
        </FloatingLabel>
    );
}

export default ComboBox;