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
        <section className="flex">
            {containers.map((container, index) => (
                <Card className="">
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
