<script setup lang="ts">
import { ref } from 'vue';
import MyInput from '@/components/ui/MyInput.vue';
import MyButton from '@/components/ui/MyButton.vue';
import axios from 'axios';

const props = defineProps<{
    reviewId: number,
}>()

const emit = defineEmits<{
  (e: 'comment-created', commentId: number): void
}>();

const content = ref()

async function sendComment () {
    try {
        const response = await axios.post('http://localhost:5007/Comment', {
            ReviewId: props.reviewId,
            Content: content.value,
        }, {
            withCredentials: true
        })

        emit('comment-created', response.data.Id);
        content.value = ''
    } catch (error) {

    }
}

async function handleSubmit() {
    if (content.value.length === 0) return
    await sendComment()
}

</script>

<template>
    <div class="flex flex-row gap-3">
        <MyInput v-model="content" placeholder="Ваше подробное мнение по этому поводу" class="w-full"/>
        <div class="flex justify-end">
            <MyButton  @click="handleSubmit" class="">Написать</MyButton>
        </div>
    </div>
</template>