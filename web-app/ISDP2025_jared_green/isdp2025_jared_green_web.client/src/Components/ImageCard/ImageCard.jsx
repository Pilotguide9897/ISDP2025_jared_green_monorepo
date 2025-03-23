import Card from 'react-bootstrap/Card';

function ImageCard({ imagePath } ) {
    return (
        <Card style={{ width: '18rem' }}>
            <Card.Img variant="top" src={ imagePath } alt="Item Image" />
        </Card>
    );
}

export default ImageCard;