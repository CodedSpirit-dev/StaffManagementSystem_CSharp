export const EmployeeCreate: React.FC = () => {
    return (
        <div>
            <h1>Alta de empleados</h1>
            <h2>Aqui puedes dar de alta a nuevos empleados</h2>
            <form className='flex flex-col items-center'>
                <div className="space-y-12">
                    <div>
                        <h2>Datos Personales</h2>
                        <div className="grid grid-cols-2 gap-4">
                            <div>
                                <label htmlFor="name">Nombre</label>
                                <input type="text" id="name" className="input_text"/>
                            </div>
                            <div>
                                <label htmlFor="lastName">Segundo nombre</label>
                                <input type="text" id="middleName" className="input_text"/>
                            </div>
                            <div>
                                <label htmlFor="lastName">Apellido</label>
                                <input type="text" id="lastName" className="input_text"/>
                            </div>
                            <div>
                                <label htmlFor="lastName">Segundo apellido</label>
                                <input type="text" id="secondLastName" className="input_text"/>
                            </div>
                            <div>
                                <label htmlFor="birthDate">Fecha de nacimiento</label>
                                <input type="date" id="birthDate" className="input_date"/>
                            </div>
                            <div>
                                <label htmlFor='gender'>Sexo</label>
                                <select name="gender" id="gender" className="input_text">
                                    <option value="male">Masculino</option>
                                    <option value="female">Femenino</option>
                                </select>
                            </div>
                            <div>
                                <label htmlFor="bloodType">Tipo de sangre</label>
                                <select name="bloodType" id="bloodType" className="input_text">
                                    <option value="A Positivo">A+</option>
                                    <option value="A Negativo">A-</option>
                                    <option value="B Positivo">B+</option>
                                    <option value="B Negativo">B-</option>
                                    <option value="AB Positivo">AB+</option>
                                    <option value="AB Negativo">AB-</option>
                                    <option value="O Positivo">O+</option>
                                    <option value="O Negativo">O-</option>
                                </select>
                            </div>
                            <div>
                                <label htmlFor="maritalStatus">Estado civil</label>
                                <select name="maritalStatus" id="maritalStatus" className="input_text">
                                    <option value="single">Soltero</option>
                                    <option value="married">Casado</option>
                                    <option value="widow">Viudo</option>
                                    <option value="divorced">Divorciado</option>
                                </select>
                            </div>
                            <div>
                                <label htmlFor="children">Identificador</label>
                                <input type="number" id="children" className="input_text" min={0} max={10} defaultValue={0}/>
                            </div>
                            <div>
                                <label htmlFor="studyGrade">Ultimo grado de estudios</label>
                                <select name="studyGrade" id="studyGrade" className="input_text">
                                    <option value="primary">Primaria</option>
                                    <option value="secondary">Secundaria</option>
                                    <option value="highSchool">Bachillerato</option>
                                    <option value="university">Licenciatura</option>
                                    <option value="Masters">Maestría</option>
                                    <option value="Doctorate">Doctorado</option>
                                </select>
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