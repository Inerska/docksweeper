"use client";

import ContainerDataTableComponent from "@/app/containers/page";

export default function DockerContainers() {

    return <section className="flex flex-col gap-10">
        <h1 className="text-3xl font-semibold">Your containers</h1>
        <ContainerDataTableComponent/>
    </section>;
}
