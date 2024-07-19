import React from 'react';
import { SucessfullModal } from '../../components/Modals/SucessfullModal';

const Home: React.FC = () => {
    return (
        <div>
            <h1 className='text-3xl font-bold text-center'>Welcome to the Home page!</h1>

            // Si se acaba de abrir el sitio mostrar modal
            <SucessfullModal />
        </div>
    );
};

export default Home;