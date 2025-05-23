<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios'
import MyInput from '@/components/ui/MyInput.vue';
</script>

<template>
    <div class="min-h-screen bg-background">
        <div class="px-5 pt-5">
            <MyInput background-color="bg-secondary" font-size="text-5xl" placeholder="Поиск..." class="w-full"></MyInput>
        </div>
    </div>
</template>