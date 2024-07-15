export const EmployeeCreate: React.FC = () => {
    return (
        <div>
            <h1 className='text-3xl font-bold text-center'>Welcome to the EmployeeCreate page!</h1>
            <form className='flex flex-col items-center'>
                <div className="space-y-12">
                    <div>
                        <h2>Datos Personales</h2>
                        <div className="grid grid-cols-2 gap-4">
                            <div>
                                <label htmlFor="name">Nombre</label>
                                <input type="text" id="name" />
                            </div>
                            <div>
                                <label htmlFor="lastName">Segundo nombre</label>
                                <input type="text" id="middleName" />
                            </div>
                            <div>
                                <label htmlFor="lastName">Apellido</label>
                                <input type="text" id="lastName" />
                            </div>
                            <div>
                                <label htmlFor="lastName">Segundo apellido</label>
                                <input type="text" id="secondLastName" />
                            </div>
                            <div>
                                <label htmlFor="birthDate">Fecha de nacimiento</label>
                                <input type="date" id="birthDate" />
                            </div>
                        </div>
                    </div>
                    <h2>Datos de vivienda</h2>
                    <h2>Datos de contacto</h2>
                    <h2>Datos de trabajo</h2>
                    <h2>Contacto de emergencia</h2>
                </div>
            </form>
        </div>
    );
};