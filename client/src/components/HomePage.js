import { useNavigate } from "react-router-dom";
import { Button } from "reactstrap";

export default function HomePage({ loggedInUser }) {
    const navigate = useNavigate();

    return (
        <>
        <div className="container">
            <h2>Welcome to Cope and Hope, we hope you are feeling well and ready to journal!</h2>
            <img
                src="./CHlogo.jpg"
                alt="logo"
                className="logo"
            />
        </div>
        <Button color="primary" onClick={() => navigate(`/newjournal/`)}>Start New Journal</Button>
        </>
    )
}