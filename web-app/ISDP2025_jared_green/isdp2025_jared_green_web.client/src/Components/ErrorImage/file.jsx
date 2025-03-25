import Image from 'react-bootstrap/Image';
import ErrorImg from '../../assets/NotFound.jpg';

function ErrorImage() {
    return <Image src={ErrorImg} fluid />;
}

export default ErrorImage;