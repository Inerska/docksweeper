"use client";

import {Inter} from 'next/font/google'
import DockerContainers from "@/components/DockerContainersComponent";

const inter = Inter({subsets: ['latin']});

export default function Home() {
    return <main>
        <h1 className="text-red-500">DockSweeper</h1>
        <DockerContainers/>
    </main>
}
