"use client";

import { useEffect, useState } from 'react';

export default function DockerContainers() {
    const [containers, setContainers] = useState([]);

    useEffect(() => {
        fetch('http://localhost:5236/api/v1/DockerContainer')
            .then(response => response.json())
            .then(data => setContainers(data));
    }, []);

    return (
        <section>
            {containers.map((container, index) => (
                <article key={index}>
                    <h1>{container.name}</h1>
                    <p>{container.status}</p>
                </article>
            ))}
        </section>
    );
}
