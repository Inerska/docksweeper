"use client";

import { useEffect, useState } from 'react';
import {Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle} from "@/components/ui/card";

export default function DockerContainers() {
    const [containers, setContainers] = useState([]);

    useEffect(() => {
        fetch('http://localhost:5236/api/v1/DockerContainer')
            .then(response => response.json())
            .then(data => setContainers(data));
    }, []);

    return (
        <section className="flex flex-col gap-10">
            <h1 className="text-3xl font-semibold">Your containers</h1>
            {containers.map((container, index) => (
                <Card className="" key={container.id}>
                    <CardHeader>
                        <CardTitle>{container.names}</CardTitle>
                        <CardDescription>{container.id}</CardDescription>
                    </CardHeader>
                    <CardContent>
                        <p>Card Content</p>
                    </CardContent>
                    <CardFooter>
                        <p>Card Footer</p>
                    </CardFooter>
                </Card>
            ))}
        </section>
    );
}
