<script setup lang="ts">
defineProps({
    sign: String,
})
</script>

<template>
    <div class="flex flex-col gap-0 items-center">
        <MyButton class="w-full">
            <slot></slot>
        </MyButton>
        <p class="font-russo leading-none text-gray-300 text-xs underline mt-1">{{ sign }}</p>
    </div>
</template>