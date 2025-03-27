import Card from 'react-bootstrap/Card';

function ImageCard({ data }) {
    console.log(`image path in image card: ${data}`)
    return (
        <div className="d-flex justify-content-center">
            <Card style={{ width: '18rem' }}>
                <h3 className="text-center">{ data.imageName }</h3>
                <Card.Img variant="top" src={`http://localhost:5175/${data.imageSrc}`} alt="Item Image" />
            </Card>
        </div>
    );
}

export default ImageCard;