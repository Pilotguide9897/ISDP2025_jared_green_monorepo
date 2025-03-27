import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import ImageCard from '../ImageCard/ImageCard';

function BasicModal({ show, onHide, image}) {
    console.log(`image path in basic modal: ${image}`);
    return (
        <Modal
            // Control whether the modal is visible.
            show={show}
            // Tells the user what to do when trying to close it, such as by clicking the button.
            onHide={ onHide }
            size="lg"
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Body>
                <ImageCard data={ image } />
            </Modal.Body>
            <Modal.Footer>
                <Button variant="info" onClick={onHide}>Close</Button>
            </Modal.Footer>
        </Modal>
    );
}

export default BasicModal;