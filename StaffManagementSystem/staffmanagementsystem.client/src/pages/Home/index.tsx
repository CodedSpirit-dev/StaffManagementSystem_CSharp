import React from 'react';
import { Link } from 'react-router-dom';
import { PrimeReactProvider, PrimeReactContext } from 'primereact/api';
import GlobalStyles from '@mui/joy/GlobalStyles';

const Home: React.FC = () => {
    return (
        <div>
            <h1 className='MuiSkeleton-h1'>Welcome to the Home page!</h1>
            <p>This is a basic home component.</p>
            <Link to="/lista">Employee List</Link>
        </div>
    );
};

export default Home;